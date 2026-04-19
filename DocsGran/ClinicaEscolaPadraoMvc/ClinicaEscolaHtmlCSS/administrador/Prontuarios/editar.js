const KEY_PATIENTS = "ce_pacientes";
const KEY_RECORDS = "ce_prontuarios";
const KEY_AUDIT = "ce_auditoria";

const params = new URLSearchParams(window.location.search);
const id = params.get("id") || "";

const numero = document.getElementById("numero");
const paciente = document.getElementById("paciente");
const situacao = document.getElementById("situacao");
const dataAbertura = document.getElementById("data");
const aluno = document.getElementById("aluno");
const professora = document.getElementById("professora");
const obs = document.getElementById("obs");
const salvar = document.getElementById("salvar");

function load(key) { return JSON.parse(localStorage.getItem(key) || "[]"); }
function save(key, data) { localStorage.setItem(key, JSON.stringify(data)); }
function audit(action, entity, entityId, details) {
	const logs = load(KEY_AUDIT);
	logs.push({ id: Date.now().toString(), action, entity, entityId, details, timestamp: new Date().toISOString() });
	save(KEY_AUDIT, logs);
}

function fillPatients() {
	const patients = load(KEY_PATIENTS).filter((p) => p.ativo);
	paciente.innerHTML = patients.length ? patients.map((p) => `<option value="${p.id}">${p.nome}</option>`).join("") : '<option value="">Sem pacientes</option>';
}

function fillData() {
	const data = load(KEY_RECORDS);
	const item = data.find((r) => r.id === id);
	if (!item) return;
	numero.value = item.numero || "";
	paciente.value = item.pacienteId || "";
	situacao.value = item.situacao || "Aberto";
	dataAbertura.value = item.dataAbertura || "";
	aluno.value = item.aluno || "";
	professora.value = item.professora || "";
	obs.value = item.observacoes || "";
}

salvar.addEventListener("click", () => {
	const data = load(KEY_RECORDS);
	const idx = data.findIndex((r) => r.id === id);
	if (idx < 0) { window.location.href = "./index.html"; return; }
	data[idx] = {
		...data[idx],
		numero: numero.value.trim(),
		pacienteId: paciente.value,
		situacao: situacao.value,
		dataAbertura: dataAbertura.value,
		aluno: aluno.value.trim(),
		professora: professora.value.trim(),
		observacoes: obs.value.trim()
	};
	save(KEY_RECORDS, data);
	audit("UPDATE", "Prontuario", id, data[idx].numero || "Sem numero");
	window.location.href = "./index.html";
});

fillPatients();
fillData();
