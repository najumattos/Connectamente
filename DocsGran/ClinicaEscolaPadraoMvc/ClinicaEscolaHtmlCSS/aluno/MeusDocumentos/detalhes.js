const ALUNO_EMAIL = "aluno@clinicaescola.edu";
const KEY_PATIENTS = "ce_pacientes";
const KEY_RECORDS = "ce_prontuarios";
const KEY_DOCS = "ce_documentos";

const params = new URLSearchParams(window.location.search);
const id = params.get("id") || "";

const docGrid = document.getElementById("doc-grid");
const goPaciente = document.getElementById("go-paciente");
const goModelo = document.getElementById("go-modelo");
const prevDoc = document.getElementById("prev-doc");
const nextDoc = document.getElementById("next-doc");
const docPicker = document.getElementById("doc-picker");

function load(key) { return JSON.parse(localStorage.getItem(key) || "[]"); }
function detail(label, value) { return `<p class="detail-item"><strong>${label}:</strong> ${value || "-"}</p>`; }

function modelUrl(tipo) {
	const routes = {
		DocumentoIdentificacaoPaciente: "documento-identificacao-paciente.html",
		AnamneseAdulto: "anamnese-adulto.html",
		AnamneseAdolescente: "anamnese-adolescente.html",
		PlantaoPsicologico: "plantao-psicologico.html",
		EvolucaoAtendimento: "evolucao-atendimento.html",
		TermoPsicoterapiaIndividual: "termo-psicoterapia-individual.html",
		TermoAutorizacaoMenor: "termo-autorizacao-menor.html",
		TermoCompromissoInformatizacao: "termo-compromisso-informatizacao.html",
		TermoResponsabilidadeEstagiario: "termo-responsabilidade-estagiario.html"
	};
	const file = routes[tipo] || "index.html";
	return `../../documentosClinicos/${file}`;
}

function render() {
	const docs = load(KEY_DOCS).filter((d) => d.autor === ALUNO_EMAIL);
	const patients = Object.fromEntries(load(KEY_PATIENTS).map((p) => [p.id, p]));
	const records = Object.fromEntries(load(KEY_RECORDS).map((r) => [r.id, r]));
	const doc = docs.find((d) => d.id === id) || docs[0];
	if (!doc) return;

	const patient = patients[doc.pacienteId];
	const prontuario = records[doc.prontuarioId];
	const patientDocs = docs
		.filter((d) => d.pacienteId === doc.pacienteId)
		.sort((a, b) => (b.dataDocumento || "").localeCompare(a.dataDocumento || ""));
	const index = patientDocs.findIndex((d) => d.id === doc.id);
	const prev = index > 0 ? patientDocs[index - 1] : null;
	const next = index >= 0 && index < patientDocs.length - 1 ? patientDocs[index + 1] : null;

	docGrid.innerHTML = [
		detail("Tipo", doc.tipo),
		detail("Paciente", patient?.nome || "-"),
		detail("Prontuário", prontuario?.numero || "-"),
		detail("Status", doc.status),
		detail("Versão", doc.versao),
		detail("Data", doc.dataDocumento),
		detail("Resumo", doc.resumo),
		detail("Ativo", doc.ativo ? "Sim" : "Não")
	].join("");

	if (patient) {
		goPaciente.href = `../MeusPacientes/detalhes.html?id=${patient.id}`;
	}
	goModelo.href = modelUrl(doc.tipo);

	prevDoc.href = prev ? `./detalhes.html?id=${prev.id}` : `./index.html`;
	nextDoc.href = next ? `./detalhes.html?id=${next.id}` : `./index.html`;

	docPicker.innerHTML = patientDocs
		.map((d) => `<option value="${d.id}" ${d.id === doc.id ? "selected" : ""}>${d.tipo || "Tipo"} • ${d.dataDocumento || "Sem data"}</option>`)
		.join("");
	docPicker.addEventListener("change", () => {
		window.location.href = `./detalhes.html?id=${docPicker.value}`;
	});
}

render();
