const KEY_PATIENTS = "ce_pacientes";
const KEY_AUDIT = "ce_auditoria";

const labelNome = document.getElementById("paciente-nome");
const labelStatus = document.getElementById("paciente-status");
const btnToggle = document.getElementById("btn-toggle");

const params = new URLSearchParams(window.location.search);
const id = params.get("id") || "";

function load(key) {
	return JSON.parse(localStorage.getItem(key) || "[]");
}

function save(key, data) {
	localStorage.setItem(key, JSON.stringify(data));
}

function audit(action, entity, entityId, details) {
	const logs = load(KEY_AUDIT);
	logs.push({
		id: Date.now().toString(),
		action,
		entity,
		entityId,
		details,
		timestamp: new Date().toISOString()
	});
	save(KEY_AUDIT, logs);
}

function currentPaciente() {
	return load(KEY_PATIENTS).find((p) => p.id === id);
}

function render() {
	const p = currentPaciente();
	if (!p) {
		labelNome.textContent = "Paciente não encontrado";
		labelStatus.textContent = "Status atual: -";
		btnToggle.disabled = true;
		return;
	}

	labelNome.textContent = p.nome || "Sem nome";
	labelStatus.textContent = `Status atual: ${p.ativo ? "Ativo" : "Inativo"}`;
	btnToggle.textContent = p.ativo ? "Inativar Paciente" : "Ativar Paciente";
}

btnToggle.addEventListener("click", () => {
	const data = load(KEY_PATIENTS);
	const idx = data.findIndex((p) => p.id === id);
	if (idx < 0) {
		window.location.href = "./index.html";
		return;
	}

	data[idx].ativo = !data[idx].ativo;
	save(KEY_PATIENTS, data);
	audit("TOGGLE", "Paciente", id, data[idx].ativo ? "Ativado" : "Inativado");
	window.location.href = "./index.html";
});

render();
