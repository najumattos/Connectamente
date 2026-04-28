const ALUNO_EMAIL = "aluno@clinicaescola.edu";
const KEY_DOCS = "ce_documentos";
const KEY_AUDIT = "ce_auditoria";

const params = new URLSearchParams(window.location.search);
const id = params.get("id") || "";

const nome = document.getElementById("nome");
const status = document.getElementById("status");
const toggle = document.getElementById("toggle");

function load(key) { return JSON.parse(localStorage.getItem(key) || "[]"); }
function save(key, data) { localStorage.setItem(key, JSON.stringify(data)); }
function audit(action, entity, entityId, details) {
	const logs = load(KEY_AUDIT);
	logs.push({ id: Date.now().toString(), action, entity, entityId, details, timestamp: new Date().toISOString() });
	save(KEY_AUDIT, logs);
}

function current() { return load(KEY_DOCS).find((d) => d.id === id && d.autor === ALUNO_EMAIL); }

function render() {
	const d = current();
	if (!d) { nome.textContent = "Documento não encontrado"; toggle.disabled = true; return; }
	nome.textContent = d.tipo || "Sem tipo";
	status.textContent = `Status: ${d.ativo ? "Ativo" : "Inativo"}`;
	toggle.textContent = d.ativo ? "Inativar" : "Ativar";
}

toggle.addEventListener("click", () => {
	const docs = load(KEY_DOCS);
	const idx = docs.findIndex((d) => d.id === id && d.autor === ALUNO_EMAIL);
	if (idx < 0) { window.location.href = "./index.html"; return; }
	docs[idx].ativo = !docs[idx].ativo;
	save(KEY_DOCS, docs);
	audit("TOGGLE", "DocumentoClinico", id, docs[idx].ativo ? "Aluno ativou documento" : "Aluno inativou documento");
	window.location.href = "./index.html";
});

render();
