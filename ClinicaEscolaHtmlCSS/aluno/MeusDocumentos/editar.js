const ALUNO_EMAIL = "aluno@clinicaescola.edu";
const KEY_PATIENTS = "ce_pacientes";
const KEY_RECORDS = "ce_prontuarios";
const KEY_DOCS = "ce_documentos";
const KEY_AUDIT = "ce_auditoria";

const params = new URLSearchParams(window.location.search);
const id = params.get("id") || "";

const tipo = document.getElementById("tipo");
const paciente = document.getElementById("paciente");
const prontuario = document.getElementById("prontuario");
const status = document.getElementById("status");
const dataDoc = document.getElementById("data");
const versao = document.getElementById("versao");
const resumo = document.getElementById("resumo");
const salvar = document.getElementById("salvar");

function load(key) { return JSON.parse(localStorage.getItem(key) || "[]"); }
function save(key, data) { localStorage.setItem(key, JSON.stringify(data)); }
function audit(action, entity, entityId, details) {
	const logs = load(KEY_AUDIT);
	logs.push({ id: Date.now().toString(), action, entity, entityId, details, timestamp: new Date().toISOString() });
	save(KEY_AUDIT, logs);
}

function patientsById() { return Object.fromEntries(load(KEY_PATIENTS).map((p) => [p.id, p])); }

function fillPatients() {
	const records = load(KEY_RECORDS).filter((r) => r.ativo && (r.aluno || "").toLowerCase().includes(ALUNO_EMAIL));
	const map = patientsById();
	const options = [...new Map(records.map((r) => [r.pacienteId, map[r.pacienteId]])).values()].filter(Boolean);
	paciente.innerHTML = options.length ? options.map((p) => `<option value="${p.id}">${p.nome}</option>`).join("") : '<option value="">Sem pacientes vinculados</option>';
}

function fillProntuarios(patientId) {
	const records = load(KEY_RECORDS).filter((r) => r.ativo && r.pacienteId === patientId && (r.aluno || "").toLowerCase().includes(ALUNO_EMAIL));
	prontuario.innerHTML = records.length ? records.map((r) => `<option value="${r.id}">${r.numero}</option>`).join("") : '<option value="">Sem prontuário</option>';
}

function fillData() {
	const docs = load(KEY_DOCS);
	const d = docs.find((item) => item.id === id && item.autor === ALUNO_EMAIL);
	if (!d) return;
	tipo.value = d.tipo || "AnamneseAdulto";
	paciente.value = d.pacienteId || "";
	fillProntuarios(d.pacienteId);
	prontuario.value = d.prontuarioId || "";
	status.value = d.status || "Rascunho";
	dataDoc.value = d.dataDocumento || "";
	versao.value = d.versao || "1";
	resumo.value = d.resumo || "";
}

paciente.addEventListener("change", () => fillProntuarios(paciente.value));

salvar.addEventListener("click", () => {
	const docs = load(KEY_DOCS);
	const idx = docs.findIndex((d) => d.id === id && d.autor === ALUNO_EMAIL);
	if (idx < 0) { window.location.href = "./index.html"; return; }
	docs[idx] = {
		...docs[idx],
		tipo: tipo.value,
		pacienteId: paciente.value,
		prontuarioId: prontuario.value,
		status: status.value,
		dataDocumento: dataDoc.value,
		versao: versao.value.trim() || "1",
		resumo: resumo.value.trim()
	};
	save(KEY_DOCS, docs);
	audit("UPDATE", "DocumentoClinico", id, "Aluno atualizou documento");
	window.location.href = "./index.html";
});

fillPatients();
fillData();
