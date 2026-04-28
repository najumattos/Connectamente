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
const autor = document.getElementById("autor");
const supervisor = document.getElementById("supervisor");
const versao = document.getElementById("versao");
const dataDoc = document.getElementById("data");
const resumo = document.getElementById("resumo");
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

function fillProntuarios(pid) {
	const records = load(KEY_RECORDS).filter((r) => r.ativo && r.pacienteId === pid);
	prontuario.innerHTML = records.length ? records.map((r) => `<option value="${r.id}">${r.numero}</option>`).join("") : '<option value="">Sem prontuário</option>';
}

function fillData() {
	const docs = load(KEY_DOCS);
	const d = docs.find((item) => item.id === id);
	if (!d) return;
	tipo.value = d.tipo || "AnamneseAdulto";
	paciente.value = d.pacienteId || "";
	fillProntuarios(d.pacienteId);
	prontuario.value = d.prontuarioId || "";
	status.value = d.status || "Rascunho";
	autor.value = d.autor || "";
	supervisor.value = d.supervisor || "";
	versao.value = d.versao || "1";
	dataDoc.value = d.dataDocumento || "";
	resumo.value = d.resumo || "";
}

paciente.addEventListener("change", () => fillProntuarios(paciente.value));

salvar.addEventListener("click", () => {
	const docs = load(KEY_DOCS);
	const idx = docs.findIndex((d) => d.id === id);
	if (idx < 0) { window.location.href = "./index.html"; return; }
	docs[idx] = {
		...docs[idx],
		tipo: tipo.value,
		pacienteId: paciente.value,
		prontuarioId: prontuario.value,
		status: status.value,
		autor: autor.value.trim(),
		supervisor: supervisor.value.trim(),
		versao: versao.value.trim() || "1",
		dataDocumento: dataDoc.value,
		resumo: resumo.value.trim()
	};
	save(KEY_DOCS, docs);
	audit("UPDATE", "DocumentoClinico", id, docs[idx].tipo || "Sem tipo");
	window.location.href = "./index.html";
});

fillPatients();
fillData();
