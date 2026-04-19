const KEY_PATIENTS = "ce_pacientes";
const KEY_DOCS = "ce_documentos";
const tbody = document.getElementById("documentos-body");
const empty = document.getElementById("documentos-empty");
const params = new URLSearchParams(window.location.search);
const pacienteIdFiltro = params.get("pacienteId") || "";

function load(key) {
	return JSON.parse(localStorage.getItem(key) || "[]");
}

function mapPatients() {
	return Object.fromEntries(load(KEY_PATIENTS).map((p) => [p.id, p]));
}

function render() {
	const docs = load(KEY_DOCS).filter((d) => !pacienteIdFiltro || d.pacienteId === pacienteIdFiltro);
	const patients = mapPatients();
	tbody.innerHTML = "";
	empty.style.display = docs.length ? "none" : "block";

	docs.forEach((d) => {
		const tr = document.createElement("tr");
		tr.innerHTML = `
			<td>${d.tipo}</td>
			<td>${patients[d.pacienteId]?.nome || "Paciente removido"}</td>
			<td>${d.status}</td>
			<td>${d.autor || "-"}</td>
			<td>${d.dataDocumento || "-"}</td>
			<td>
				<div class="table-actions">
					<a class="btn btn-ghost" href="./detalhes.html?id=${d.id}">Detalhes</a>
					<a class="btn btn-ghost" href="./editar.html?id=${d.id}">Editar</a>
					<a class="btn btn-ghost" href="./status.html?id=${d.id}">${d.ativo ? "Inativar" : "Ativar"}</a>
				</div>
			</td>
		`;
		tbody.appendChild(tr);
	});
}
render();
