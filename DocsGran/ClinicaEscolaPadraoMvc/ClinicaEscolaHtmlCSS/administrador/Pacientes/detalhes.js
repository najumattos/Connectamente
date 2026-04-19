const KEY_PATIENTS = "ce_pacientes";
const KEY_RECORDS = "ce_prontuarios";
const KEY_DOCS = "ce_documentos";
const KEY_SESSIONS = "ce_sessoes";

const params = new URLSearchParams(window.location.search);
const id = params.get("id") || "";

const pacienteGrid = document.getElementById("paciente-grid");
const prontuarioResumo = document.getElementById("prontuario-resumo");
const goProntuario = document.getElementById("go-prontuario");
const goDocumentos = document.getElementById("go-documentos");
const tbody = document.getElementById("docs-body");
const empty = document.getElementById("docs-empty");

function load(key) {
	return JSON.parse(localStorage.getItem(key) || "[]");
}

function detail(label, value) {
	return `<p class="detail-item"><strong>${label}:</strong> ${value || "-"}</p>`;
}

function render() {
	const patients = load(KEY_PATIENTS);
	const records = load(KEY_RECORDS);
	const docs = load(KEY_DOCS);
	const sessions = load(KEY_SESSIONS);

	const patient = patients.find((p) => p.id === id) || patients[0];
	if (!patient) return;

	const prontuario = records.find((r) => r.pacienteId === patient.id);
	const patientDocs = docs.filter((d) => d.pacienteId === patient.id);
	const patientSessions = sessions.filter((s) => s.pacienteId === patient.id);
	const evolucoes = patientDocs.filter((d) => d.tipo === "EvolucaoAtendimento");

	pacienteGrid.innerHTML = [
		detail("Nome", patient.nome),
		detail("CPF", patient.cpf),
		detail("Data Nascimento", patient.nascimento),
		detail("Telefone", patient.telefone),
		detail("Observações", patient.observacoes),
		detail("Status", patient.ativo ? "Ativo" : "Inativo")
	].join("");

	prontuarioResumo.innerHTML = prontuario
		? [
			detail("Número", prontuario.numero),
			detail("Situação", prontuario.situacao),
			detail("Aluno", prontuario.aluno),
			detail("Data Abertura", prontuario.dataAbertura),
			detail("Atendimentos", String(patientSessions.length)),
			detail("Evoluções", String(evolucoes.length))
		].join("")
		: detail("Prontuário", "Não localizado");

	if (prontuario) {
		goProntuario.href = `../Prontuarios/detalhes.html?id=${prontuario.id}`;
		goDocumentos.href = `../Documentos/index.html?pacienteId=${patient.id}`;
	}

	tbody.innerHTML = "";
	empty.style.display = patientDocs.length ? "none" : "block";
	patientDocs
		.sort((a, b) => (b.dataDocumento || "").localeCompare(a.dataDocumento || ""))
		.forEach((d, index) => {
			const prev = patientDocs[index - 1];
			const next = patientDocs[index + 1];
			const tr = document.createElement("tr");
			tr.innerHTML = `
				<td>${d.tipo || "-"}</td>
				<td>${d.status || "-"}</td>
				<td>${d.autor || "-"}</td>
				<td>${d.dataDocumento || "-"}</td>
				<td>
					<div class="table-actions">
						<a class="btn btn-ghost" href="../Documentos/detalhes.html?id=${d.id}">Ver</a>
						${prev ? `<a class="btn btn-ghost" href="../Documentos/detalhes.html?id=${prev.id}">Anterior</a>` : ""}
						${next ? `<a class="btn btn-ghost" href="../Documentos/detalhes.html?id=${next.id}">Próximo</a>` : ""}
					</div>
				</td>
			`;
			tbody.appendChild(tr);
		});
}

render();
