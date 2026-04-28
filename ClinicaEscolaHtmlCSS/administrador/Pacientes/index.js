const KEY_PATIENTS = "ce_pacientes";
const busca = document.getElementById("paciente-busca");
const tbody = document.getElementById("pacientes-body");
const empty = document.getElementById("pacientes-empty");

function load(key) {
	return JSON.parse(localStorage.getItem(key) || "[]");
}

function render() {
	const q = busca.value.trim().toLowerCase();
	const data = load(KEY_PATIENTS).filter((p) => {
		if (!q) return true;
		return p.nome.toLowerCase().includes(q) || p.cpf.toLowerCase().includes(q);
	});

	tbody.innerHTML = "";
	empty.style.display = data.length ? "none" : "block";

	data.forEach((p) => {
		const tr = document.createElement("tr");
		tr.innerHTML = `
			<td>${p.nome}</td>
			<td>${p.cpf}</td>
			<td>${p.nascimento || "-"}</td>
			<td>${p.telefone || "-"}</td>
			<td>${p.ativo ? "Ativo" : "Inativo"}</td>
			<td>
				<div class="table-actions">
					<a class="btn btn-ghost" href="./detalhes.html?id=${p.id}">Detalhes</a>
					<a class="btn btn-ghost" href="./editar.html?id=${p.id}">Editar</a>
					<a class="btn btn-ghost" href="./status.html?id=${p.id}">${p.ativo ? "Inativar" : "Ativar"}</a>
				</div>
			</td>
		`;
		tbody.appendChild(tr);
	});
}
busca.addEventListener("input", render);

render();
