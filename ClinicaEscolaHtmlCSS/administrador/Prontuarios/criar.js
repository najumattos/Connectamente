const KEY_PATIENTS = "ce_pacientes";
const KEY_RECORDS = "ce_prontuarios";
const KEY_AUDIT = "ce_auditoria";

const numero = document.getElementById("numero");
const paciente = document.getElementById("paciente");
const situacao = document.getElementById("situacao");
const dataAbertura = document.getElementById("data");
const aluno = document.getElementById("aluno");
const professora = document.getElementById("professora");
const obs = document.getElementById("obs");
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

salvar.addEventListener("click", () => {
	const records = load(KEY_RECORDS);
	const item = {
		id: `${Date.now()}-${Math.floor(Math.random() * 1000)}`,
		numero: numero.value.trim(),
		pacienteId: paciente.value,
		situacao: situacao.value,
		dataAbertura: dataAbertura.value,
		aluno: aluno.value.trim(),
		professora: professora.value.trim(),
		observacoes: obs.value.trim(),
		ativo: true
	};
	records.push(item);
	save(KEY_RECORDS, records);
	audit("CREATE", "Prontuario", item.id, item.numero || "Sem numero");
	window.location.href = "./index.html";
});

fillPatients();
