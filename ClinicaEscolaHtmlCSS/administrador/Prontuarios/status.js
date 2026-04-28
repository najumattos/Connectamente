const KEY_RECORDS = "ce_prontuarios";
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

function current() { return load(KEY_RECORDS).find((r) => r.id === id); }

function render() {
	const item = current();
	if (!item) { nome.textContent = "Prontuário não encontrado"; toggle.disabled = true; return; }
	nome.textContent = item.numero || "Sem número";
	status.textContent = `Status: ${item.ativo ? "Ativo" : "Inativo"}`;
	toggle.textContent = item.ativo ? "Inativar" : "Ativar";
}

toggle.addEventListener("click", () => {
	const data = load(KEY_RECORDS);
	const idx = data.findIndex((r) => r.id === id);
	if (idx < 0) { window.location.href = "./index.html"; return; }
	data[idx].ativo = !data[idx].ativo;
	save(KEY_RECORDS, data);
	audit("TOGGLE", "Prontuario", id, data[idx].ativo ? "Ativado" : "Inativado");
	window.location.href = "./index.html";
});

render();
