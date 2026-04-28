const ALUNO_EMAIL = "aluno@clinicaescola.edu";
const KEY_PATIENTS = "ce_pacientes";
const KEY_RECORDS = "ce_prontuarios";
const KEY_SESSIONS = "ce_sessoes";
const KEY_AUDIT = "ce_auditoria";

const el = {
	id: document.getElementById("sessao-id"),
	paciente: document.getElementById("sessao-paciente"),
	prontuario: document.getElementById("sessao-prontuario"),
	data: document.getElementById("sessao-data"),
	status: document.getElementById("sessao-status"),
	evolucao: document.getElementById("sessao-evolucao")
};

const btnSalvar = document.getElementById("sessao-salvar");
const btnLimpar = document.getElementById("sessao-limpar");
const tbody = document.getElementById("sessoes-body");
const empty = document.getElementById("sessoes-empty");

function load(key) {
	return JSON.parse(localStorage.getItem(key) || "[]");
}

function save(key, data) {
	localStorage.setItem(key, JSON.stringify(data));
}

function audit(action, entity, entityId, details) {
	const logs = load(KEY_AUDIT);
	logs.push({ id: Date.now().toString(), action, entity, entityId, details, timestamp: new Date().toISOString() });
	save(KEY_AUDIT, logs);
}

function allowedRecords() {
	return load(KEY_RECORDS).filter((r) => r.ativo && (r.aluno || "").toLowerCase().includes(ALUNO_EMAIL));
}

function patientsById() {
	return Object.fromEntries(load(KEY_PATIENTS).map((p) => [p.id, p]));
}

function fillPatients() {
	const map = patientsById();
	const options = allowedRecords().map((r) => ({ id: r.pacienteId, nome: map[r.pacienteId]?.nome || "Paciente" }));
	const unique = [...new Map(options.map((o) => [o.id, o])).values()];
	el.paciente.innerHTML = unique.length
		? unique.map((p) => `<option value="${p.id}">${p.nome}</option>`).join("")
		: '<option value="">Sem pacientes vinculados</option>';
}

function fillProntuarios(patientId) {
	const records = allowedRecords().filter((r) => r.pacienteId === patientId);
	el.prontuario.innerHTML = records.length
		? records.map((r) => `<option value="${r.id}">${r.numero}</option>`).join("")
		: '<option value="">Sem prontuário</option>';
}

function resetForm() {
	el.id.value = "";
	el.data.value = "";
	el.status.value = "Rascunho";
	el.evolucao.value = "";
}

function render() {
	const sessions = load(KEY_SESSIONS).filter((s) => s.autor === ALUNO_EMAIL);
	const patients = patientsById();
	tbody.innerHTML = "";
	empty.style.display = sessions.length ? "none" : "block";

	sessions.forEach((s) => {
		const tr = document.createElement("tr");
		tr.innerHTML = `
			<td>${s.dataSessao || "-"}</td>
			<td>${patients[s.pacienteId]?.nome || "Paciente"}</td>
			<td>${s.status}</td>
			<td>
				<div class="table-actions">
					<button class="btn btn-ghost" data-action="edit" data-id="${s.id}" type="button">Editar</button>
					<button class="btn btn-ghost" data-action="delete" data-id="${s.id}" type="button">Excluir</button>
				</div>
			</td>
		`;
		tbody.appendChild(tr);
	});
}

btnSalvar.addEventListener("click", () => {
	const payload = {
		id: el.id.value || `${Date.now()}-${Math.floor(Math.random() * 1000)}`,
		autor: ALUNO_EMAIL,
		pacienteId: el.paciente.value,
		prontuarioId: el.prontuario.value,
		dataSessao: el.data.value,
		status: el.status.value,
		evolucao: el.evolucao.value.trim()
	};

	const data = load(KEY_SESSIONS);
	const idx = data.findIndex((s) => s.id === payload.id);
	if (idx >= 0) {
		data[idx] = payload;
		audit("UPDATE", "EvolucaoAtendimento", payload.id, "Aluno atualizou sessão");
	} else {
		data.push(payload);
		audit("CREATE", "EvolucaoAtendimento", payload.id, "Aluno criou sessão");
	}

	save(KEY_SESSIONS, data);
	resetForm();
	render();
});

btnLimpar.addEventListener("click", resetForm);
el.paciente.addEventListener("change", () => fillProntuarios(el.paciente.value));

tbody.addEventListener("click", (e) => {
	const target = e.target;
	if (!(target instanceof HTMLElement)) return;
	const { action, id } = target.dataset;
	if (!action || !id) return;

	const data = load(KEY_SESSIONS);
	const idx = data.findIndex((s) => s.id === id && s.autor === ALUNO_EMAIL);
	if (idx < 0) return;

	if (action === "edit") {
		const s = data[idx];
		el.id.value = s.id;
		el.paciente.value = s.pacienteId;
		fillProntuarios(s.pacienteId);
		el.prontuario.value = s.prontuarioId;
		el.data.value = s.dataSessao;
		el.status.value = s.status;
		el.evolucao.value = s.evolucao || "";
	}

	if (action === "delete") {
		data.splice(idx, 1);
		audit("DELETE", "EvolucaoAtendimento", id, "Aluno removeu sessão");
		save(KEY_SESSIONS, data);
		render();
	}
});

fillPatients();
fillProntuarios(el.paciente.value);
render();
