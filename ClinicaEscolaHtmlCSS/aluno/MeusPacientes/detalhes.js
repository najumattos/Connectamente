const KEY_PATIENTS = "ce_pacientes";
const KEY_RECORDS = "ce_prontuarios";
const KEY_DOCS = "ce_documentos";
const KEY_SESSIONS = "ce_sessoes";
const ALUNO_EMAIL = "aluno@clinicaescola.edu";

const dNome = document.getElementById("d-nome");
const dCpf = document.getElementById("d-cpf");
const dNascimento = document.getElementById("d-nascimento");
const dTelefone = document.getElementById("d-telefone");
const dObservacoes = document.getElementById("d-observacoes");
const dResumoVinculos = document.getElementById("d-resumo-vinculos");
const docsBody = document.getElementById("docs-body");
const docsEmpty = document.getElementById("docs-empty");

const params = new URLSearchParams(window.location.search);
const id = params.get("id") || "";

function load(key) {
	return JSON.parse(localStorage.getItem(key) || "[]");
}

function detail(label, value) {
	return `<p class="detail-item"><strong>${label}:</strong> ${value || "-"}</p>`;
}

function render() {
	const patients = load(KEY_PATIENTS);
	const records = load(KEY_RECORDS);
	const docs = load(KEY_DOCS);
	const sessions = load(KEY_SESSIONS);

	const p = patients.find((item) => item.id === id) || patients[0];
	if (!p) return;

	const myRecords = records.filter((r) => r.pacienteId === p.id && (r.aluno || "").toLowerCase().includes(ALUNO_EMAIL));
	const myDocs = docs
		.filter((d) => d.pacienteId === p.id && d.autor === ALUNO_EMAIL)
		.sort((a, b) => (b.dataDocumento || "").localeCompare(a.dataDocumento || ""));
	const mySessions = sessions.filter((s) => s.pacienteId === p.id && s.autor === ALUNO_EMAIL);

	dNome.textContent = p.nome || "-";
	dCpf.textContent = p.cpf || "-";
	dNascimento.textContent = p.nascimento || "-";
	dTelefone.textContent = p.telefone || "-";
	dObservacoes.textContent = p.observacoes || "-";

	dResumoVinculos.innerHTML = [
		detail("Prontuários vinculados", String(myRecords.length)),
		detail("Documentos criados", String(myDocs.length)),
		detail("Atendimentos", String(mySessions.length)),
		detail("Último documento", myDocs[0]?.tipo || "-")
	].join("");

	docsBody.innerHTML = "";
	docsEmpty.style.display = myDocs.length ? "none" : "block";
	myDocs.forEach((d, index) => {
		const prev = myDocs[index - 1];
		const next = myDocs[index + 1];
		const tr = document.createElement("tr");
		tr.innerHTML = `
			<td>${d.tipo || "-"}</td>
			<td>${d.status || "-"}</td>
			<td>${d.dataDocumento || "-"}</td>
			<td>
				<div class="table-actions">
					<a class="btn btn-ghost" href="../MeusDocumentos/detalhes.html?id=${d.id}">Ver</a>
					${prev ? `<a class="btn btn-ghost" href="../MeusDocumentos/detalhes.html?id=${prev.id}">Anterior</a>` : ""}
					${next ? `<a class="btn btn-ghost" href="../MeusDocumentos/detalhes.html?id=${next.id}">Próximo</a>` : ""}
				</div>
			</td>
		`;
		docsBody.appendChild(tr);
	});
}

render();
