const KEY_PATIENTS = "ce_pacientes";
const KEY_RECORDS = "ce_prontuarios";
const KEY_DOCS = "ce_documentos";
const KEY_SESSIONS = "ce_sessoes";

const params = new URLSearchParams(window.location.search);
const id = params.get("id") || "";

const prontuarioGrid = document.getElementById("prontuario-grid");
const goPaciente = document.getElementById("go-paciente");
const goDocumentos = document.getElementById("go-documentos");
const sessBody = document.getElementById("sess-body");
const sessEmpty = document.getElementById("sess-empty");
const docsBody = document.getElementById("docs-body");
const docsEmpty = document.getElementById("docs-empty");

function load(key) { return JSON.parse(localStorage.getItem(key) || "[]"); }
function detail(label, value) { return `<p class="detail-item"><strong>${label}:</strong> ${value || "-"}</p>`; }

function render() {
	const records = load(KEY_RECORDS);
	const patients = Object.fromEntries(load(KEY_PATIENTS).map((p) => [p.id, p]));
	const sessions = load(KEY_SESSIONS);
	const docs = load(KEY_DOCS);

	const prontuario = records.find((r) => r.id === id) || records[0];
	if (!prontuario) return;
	const paciente = patients[prontuario.pacienteId];
	const linkedSessions = sessions.filter((s) => s.prontuarioId === prontuario.id);
	const linkedDocs = docs
		.filter((d) => d.prontuarioId === prontuario.id)
		.sort((a, b) => (b.dataDocumento || "").localeCompare(a.dataDocumento || ""));

	prontuarioGrid.innerHTML = [
		detail("Número", prontuario.numero),
		detail("Paciente", paciente?.nome || "-"),
		detail("Situação", prontuario.situacao),
		detail("Aluno", prontuario.aluno),
		detail("Professora", prontuario.professora),
		detail("Abertura", prontuario.dataAbertura),
		detail("Atendimentos", String(linkedSessions.length)),
		detail("Documentos", String(linkedDocs.length))
	].join("");

	if (paciente) {
		goPaciente.href = `../Pacientes/detalhes.html?id=${paciente.id}`;
		goDocumentos.href = `../Documentos/index.html?pacienteId=${paciente.id}`;
	}

	sessBody.innerHTML = "";
	sessEmpty.style.display = linkedSessions.length ? "none" : "block";
	linkedSessions.forEach((s) => {
		const tr = document.createElement("tr");
		tr.innerHTML = `<td>${s.dataSessao || "-"}</td><td>${s.status || "-"}</td><td>${s.evolucao || "-"}</td>`;
		sessBody.appendChild(tr);
	});

	docsBody.innerHTML = "";
	docsEmpty.style.display = linkedDocs.length ? "none" : "block";
	linkedDocs.forEach((d, index) => {
		const prev = linkedDocs[index - 1];
		const next = linkedDocs[index + 1];
		const tr = document.createElement("tr");
		tr.innerHTML = `
			<td>${d.tipo || "-"}</td>
			<td>${d.status || "-"}</td>
			<td>${d.dataDocumento || "-"}</td>
			<td>
				<div class="table-actions">
					<a class="btn btn-ghost" href="../Documentos/detalhes.html?id=${d.id}">Ver</a>
					${prev ? `<a class="btn btn-ghost" href="../Documentos/detalhes.html?id=${prev.id}">Anterior</a>` : ""}
					${next ? `<a class="btn btn-ghost" href="../Documentos/detalhes.html?id=${next.id}">Próximo</a>` : ""}
				</div>
			</td>
		`;
		docsBody.appendChild(tr);
	});
}

render();
