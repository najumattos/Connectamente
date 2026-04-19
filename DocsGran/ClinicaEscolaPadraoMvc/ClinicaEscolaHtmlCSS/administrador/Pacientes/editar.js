const KEY_PATIENTS = "ce_pacientes";
const KEY_AUDIT = "ce_auditoria";

const nome = document.getElementById("paciente-nome");
const cpf = document.getElementById("paciente-cpf");
const nascimento = document.getElementById("paciente-nascimento");
const telefone = document.getElementById("paciente-telefone");
const observacoes = document.getElementById("paciente-observacoes");
const btnSalvar = document.getElementById("paciente-salvar");

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

function fillForm() {
	const data = load(KEY_PATIENTS);
	const paciente = data.find((p) => p.id === id);
	if (!paciente) return;

	nome.value = paciente.nome || "";
	cpf.value = paciente.cpf || "";
	nascimento.value = paciente.nascimento || "";
	telefone.value = paciente.telefone || "";
	observacoes.value = paciente.observacoes || "";
}

btnSalvar.addEventListener("click", () => {
	const data = load(KEY_PATIENTS);
	const idx = data.findIndex((p) => p.id === id);
	if (idx < 0) {
		window.location.href = "./index.html";
		return;
	}

	data[idx] = {
		...data[idx],
		nome: nome.value.trim(),
		cpf: cpf.value.trim(),
		nascimento: nascimento.value,
		telefone: telefone.value.trim(),
		observacoes: observacoes.value.trim()
	};

	save(KEY_PATIENTS, data);
	audit("UPDATE", "Paciente", id, data[idx].nome || "Sem nome");
	window.location.href = "./index.html";
});

fillForm();
