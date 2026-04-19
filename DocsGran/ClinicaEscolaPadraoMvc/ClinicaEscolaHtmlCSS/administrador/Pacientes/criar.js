const KEY_PATIENTS = "ce_pacientes";
const KEY_AUDIT = "ce_auditoria";

const nome = document.getElementById("paciente-nome");
const cpf = document.getElementById("paciente-cpf");
const nascimento = document.getElementById("paciente-nascimento");
const telefone = document.getElementById("paciente-telefone");
const observacoes = document.getElementById("paciente-observacoes");
const btnSalvar = document.getElementById("paciente-salvar");

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

btnSalvar.addEventListener("click", () => {
	const data = load(KEY_PATIENTS);
	const paciente = {
		id: `${Date.now()}-${Math.floor(Math.random() * 1000)}`,
		nome: nome.value.trim(),
		cpf: cpf.value.trim(),
		nascimento: nascimento.value,
		telefone: telefone.value.trim(),
		observacoes: observacoes.value.trim(),
		ativo: true
	};

	data.push(paciente);
	save(KEY_PATIENTS, data);
	audit("CREATE", "Paciente", paciente.id, paciente.nome || "Sem nome");
	window.location.href = "./index.html";
});
