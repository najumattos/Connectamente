const ALUNO_EMAIL = "aluno@clinicaescola.edu";
const KEY_PATIENTS = "ce_pacientes";
const KEY_RECORDS = "ce_prontuarios";

const tbody = document.getElementById("meus-pacientes-body");
const empty = document.getElementById("meus-pacientes-empty");

function load(key) {
	return JSON.parse(localStorage.getItem(key) || "[]");
}

function render() {
	const patients = Object.fromEntries(load(KEY_PATIENTS).map((p) => [p.id, p]));
	const records = load(KEY_RECORDS).filter((r) => r.ativo && (r.aluno || "").toLowerCase().includes(ALUNO_EMAIL));
	tbody.innerHTML = "";
	empty.style.display = records.length ? "none" : "block";

	records.forEach((r) => {
		const p = patients[r.pacienteId];
		const tr = document.createElement("tr");
		tr.innerHTML = `
			<td>${p ? p.nome : "Paciente não encontrado"}</td>
			<td>${r.numero}</td>
			<td>${r.situacao}</td>
			<td>${r.professora || "-"}</td>
			<td>
				<div class="table-actions">
					<a class="btn btn-ghost" href="./detalhes.html?id=${r.pacienteId}">Detalhes</a>
					<a class="btn btn-ghost" href="../MinhasSessoes/index.html">Sessões</a>
				</div>
			</td>
		`;
		tbody.appendChild(tr);
	});
}

render();
