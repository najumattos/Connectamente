const KEY_LINKS = "ce_vinculos";
const KEY_PATIENTS = "ce_pacientes";

const busca = document.getElementById("vinculo-busca");
const tbody = document.getElementById("vinculos-body");
const empty = document.getElementById("vinculos-empty");

function load(key) {
	return JSON.parse(localStorage.getItem(key) || "[]");
}

function migrateLinksPatientIdsIfNeeded() {
	const links = load(KEY_LINKS);
	const patients = load(KEY_PATIENTS);
	if (!Array.isArray(links) || links.length === 0) return;
	if (!Array.isArray(patients) || patients.length === 0) return;

	const validIds = new Set(patients.map((p) => p.id));
	if (!links.some((v) => !validIds.has(v.pacienteId))) return;

	const fallbackIds = patients.map((p) => p.id);
	const unknownMap = {};
	let unknownCursor = 0;

	const migrated = links.map((v) => {
		if (validIds.has(v.pacienteId)) return v;
		const unknownKey = v.pacienteId || "__empty__";
		if (!unknownMap[unknownKey]) {
			unknownMap[unknownKey] = fallbackIds[unknownCursor % fallbackIds.length];
			unknownCursor += 1;
		}

		return {
			...v,
			pacienteId: unknownMap[unknownKey],
			observacoes: v.observacoes
				? `${v.observacoes} | pacienteId migrado automaticamente`
				: "pacienteId migrado automaticamente"
		};
	});

	localStorage.setItem(KEY_LINKS, JSON.stringify(migrated));
}

function mapPatients() {
	return Object.fromEntries(load(KEY_PATIENTS).map((p) => [p.id, p]));
}

function permissoes(v) {
	if (v.permiteLeitura && v.permiteEscrita) return "Leitura e Escrita";
	if (v.permiteLeitura) return "Somente Leitura";
	if (v.permiteEscrita) return "Somente Escrita";
	return "Sem permissao";
}

function render() {
	const q = busca.value.trim().toLowerCase();
	const links = load(KEY_LINKS);
	const patients = mapPatients();

	const filtered = links.filter((v) => {
		if (!q) return true;
		const patient = patients[v.pacienteId]?.nome || "";
		return (
			patient.toLowerCase().includes(q) ||
			(v.alunoEmail || "").toLowerCase().includes(q) ||
			(v.status || "").toLowerCase().includes(q)
		);
	});

	tbody.innerHTML = "";
	empty.style.display = filtered.length ? "none" : "block";

	filtered.forEach((v) => {
		const patientName = patients[v.pacienteId]?.nome || `Paciente não encontrado (${v.pacienteId || "sem id"})`;
		const tr = document.createElement("tr");
		tr.innerHTML = `
			<td>${patientName}</td>
			<td>${v.alunoEmail || "-"}</td>
			<td>${permissoes(v)}</td>
			<td>${v.dataLiberacao || "-"}</td>
			<td>${v.liberadoPor || "-"}</td>
			<td>${v.status || "-"}</td>
		`;
		tbody.appendChild(tr);
	});
}

busca.addEventListener("input", render);
migrateLinksPatientIdsIfNeeded();
render();
