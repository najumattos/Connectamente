const KEY_PATIENTS = "ce_pacientes";
const KEY_RECORDS = "ce_prontuarios";
const tbody = document.getElementById("prontuarios-body");
const empty = document.getElementById("prontuarios-empty");

function load(key) {
	return JSON.parse(localStorage.getItem(key) || "[]");
}

function patientsById() {
	return Object.fromEntries(load(KEY_PATIENTS).map((p) => [p.id, p]));
}

function render() {
	const data = load(KEY_RECORDS);
	const map = patientsById();
	tbody.innerHTML = "";
	empty.style.display = data.length ? "none" : "block";

	data.forEach((r) => {
		const patient = map[r.pacienteId];
		const tr = document.createElement("tr");
		tr.innerHTML = `
			<td>${r.numero}</td>
			<td>${patient ? patient.nome : "Paciente removido"}</td>
			<td>${r.situacao}</td>
			<td>${r.aluno || "-"}</td>
			<td>${r.ativo ? "Ativo" : "Inativo"}</td>
			<td>
				<div class="table-actions">
					<a class="btn btn-ghost" href="./detalhes.html?id=${r.id}">Detalhes</a>
					<a class="btn btn-ghost" href="./editar.html?id=${r.id}">Editar</a>
					<a class="btn btn-ghost" href="./status.html?id=${r.id}">${r.ativo ? "Inativar" : "Ativar"}</a>
				</div>
			</td>
		`;
		tbody.appendChild(tr);
	});
}
render();
