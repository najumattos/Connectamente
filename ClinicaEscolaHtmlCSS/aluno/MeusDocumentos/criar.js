const ALUNO_EMAIL = "aluno@clinicaescola.edu";
const KEY_PATIENTS = "ce_pacientes";
const KEY_RECORDS = "ce_prontuarios";
const KEY_DOCS = "ce_documentos";
const KEY_AUDIT = "ce_auditoria";

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

paciente.addEventListener("change", () => fillProntuarios(paciente.value));

salvar.addEventListener("click", () => {
	const docs = load(KEY_DOCS);
	const item = {
		id: `${Date.now()}-${Math.floor(Math.random() * 1000)}`,
		tipo: tipo.value,
		pacienteId: paciente.value,
		prontuarioId: prontuario.value,
		status: status.value,
		autor: ALUNO_EMAIL,
		supervisor: "professora@clinicaescola.edu",
		versao: versao.value.trim() || "1",
		dataDocumento: dataDoc.value,
		resumo: resumo.value.trim(),
		ativo: true
	};
	docs.push(item);
	save(KEY_DOCS, docs);
	audit("CREATE", "DocumentoClinico", item.id, "Aluno criou documento");
	window.location.href = "./index.html";
});

fillPatients();
fillProntuarios(paciente.value);
