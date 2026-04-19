const btnEnter = document.getElementById("btn-enter");
const btnFill = document.getElementById("btn-fill");

const loginEmail = document.getElementById("login-email");
const loginPassword = document.getElementById("login-password");

const KEY_ALUNOS = "ce_alunos";
const KEY_PATIENTS = "ce_pacientes";
const KEY_RECORDS = "ce_prontuarios";
const KEY_LINKS = "ce_vinculos";
const KEY_DOCS = "ce_documentos";
const KEY_SESSIONS = "ce_sessoes";
const KEY_AUDIT = "ce_auditoria";

function readList(key) {
    return JSON.parse(localStorage.getItem(key) || "[]");
}

function seedIfEmpty(key, data) {
    const current = readList(key);
    if (!Array.isArray(current) || current.length === 0) {
        localStorage.setItem(key, JSON.stringify(data));
    }
}

function migrateLinksPatientIds() {
    const links = readList(KEY_LINKS);
    const patients = readList(KEY_PATIENTS);
    if (!Array.isArray(links) || links.length === 0) return;
    if (!Array.isArray(patients) || patients.length === 0) return;

    const validIds = new Set(patients.map((p) => p.id));
    const hasInvalid = links.some((v) => !validIds.has(v.pacienteId));
    if (!hasInvalid) return;

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

function seedDemoData() {
    seedIfEmpty(KEY_ALUNOS, [
        { id: "al-1", nome: "Lucas Martins", email: "aluno@clinicaescola.edu", ativo: true },
        { id: "al-2", nome: "Bruna Souza", email: "aluna@clinicaescola.edu", ativo: true },
        { id: "al-3", nome: "Rafael Costa", email: "rafael@clinicaescola.edu", ativo: true }
    ]);

    seedIfEmpty(KEY_PATIENTS, [
        {
            id: "pac-1",
            nome: "Camila Andrade",
            cpf: "111.222.333-44",
            nascimento: "1998-05-14",
            telefone: "(11) 98888-1111",
            observacoes: "Primeiro acolhimento realizado.",
            ativo: true
        },
        {
            id: "pac-2",
            nome: "Joao Pedro Lima",
            cpf: "555.666.777-88",
            nascimento: "2001-09-23",
            telefone: "(11) 97777-2222",
            observacoes: "Encaminhado pelo serviço escola.",
            ativo: true
        },
        {
            id: "pac-3",
            nome: "Mariana Nunes",
            cpf: "999.111.222-33",
            nascimento: "1996-12-02",
            telefone: "(11) 96666-3333",
            observacoes: "Atendimento em supervisão semanal.",
            ativo: true
        }
    ]);

    seedIfEmpty(KEY_RECORDS, [
        {
            id: "pr-1",
            numero: "PR-2026-0019",
            pacienteId: "pac-1",
            situacao: "Em atendimento",
            dataAbertura: "2026-04-01",
            aluno: "aluno@clinicaescola.edu",
            professora: "professora@clinicaescola.edu",
            observacoes: "Plano terapêutico em andamento.",
            ativo: true
        },
        {
            id: "pr-2",
            numero: "PR-2026-0024",
            pacienteId: "pac-2",
            situacao: "Aberto",
            dataAbertura: "2026-04-05",
            aluno: "aluno@clinicaescola.edu",
            professora: "professora@clinicaescola.edu",
            observacoes: "Fase inicial de coleta de dados.",
            ativo: true
        },
        {
            id: "pr-3",
            numero: "PR-2026-0031",
            pacienteId: "pac-3",
            situacao: "Em atendimento",
            dataAbertura: "2026-03-28",
            aluno: "aluna@clinicaescola.edu",
            professora: "professora@clinicaescola.edu",
            observacoes: "Caso acompanhado por outro estagiário.",
            ativo: true
        }
    ]);

    const patientsForLinks = readList(KEY_PATIENTS);
    const p1 = patientsForLinks[0]?.id || "pac-1";
    const p2 = patientsForLinks[1]?.id || p1;
    const p3 = patientsForLinks[2]?.id || p2;

    seedIfEmpty(KEY_LINKS, [
        {
            id: "vin-1",
            pacienteId: p1,
            alunoEmail: "aluno@clinicaescola.edu",
            liberadoPor: "professora@clinicaescola.edu",
            dataLiberacao: "2026-04-02",
            permiteLeitura: true,
            permiteEscrita: true,
            status: "Ativo",
            observacoes: "Vinculo inicial para estagio supervisionado"
        },
        {
            id: "vin-2",
            pacienteId: p2,
            alunoEmail: "aluno@clinicaescola.edu",
            liberadoPor: "professora@clinicaescola.edu",
            dataLiberacao: "2026-04-06",
            permiteLeitura: true,
            permiteEscrita: true,
            status: "Ativo",
            observacoes: "Acompanhamento de caso novo"
        },
        {
            id: "vin-3",
            pacienteId: p3,
            alunoEmail: "aluna@clinicaescola.edu",
            liberadoPor: "professora@clinicaescola.edu",
            dataLiberacao: "2026-03-29",
            permiteLeitura: true,
            permiteEscrita: false,
            status: "Revogado",
            observacoes: "Acesso somente historico"
        }
    ]);

    seedIfEmpty(KEY_DOCS, [
        {
            id: "doc-1",
            tipo: "AnamneseAdulto",
            pacienteId: "pac-1",
            prontuarioId: "pr-1",
            status: "Em revisão",
            autor: "aluno@clinicaescola.edu",
            supervisor: "professora@clinicaescola.edu",
            versao: "1",
            dataDocumento: "2026-04-12",
            resumo: "Anamnese inicial completa.",
            ativo: true
        },
        {
            id: "doc-2",
            tipo: "EvolucaoAtendimento",
            pacienteId: "pac-2",
            prontuarioId: "pr-2",
            status: "Rascunho",
            autor: "aluno@clinicaescola.edu",
            supervisor: "professora@clinicaescola.edu",
            versao: "2",
            dataDocumento: "2026-04-16",
            resumo: "Evolução da segunda sessão.",
            ativo: true
        },
        {
            id: "doc-3",
            tipo: "PlantaoPsicologico",
            pacienteId: "pac-3",
            prontuarioId: "pr-3",
            status: "Finalizado",
            autor: "aluna@clinicaescola.edu",
            supervisor: "professora@clinicaescola.edu",
            versao: "1",
            dataDocumento: "2026-04-10",
            resumo: "Registro de atendimento pontual.",
            ativo: true
        }
    ]);

    seedIfEmpty(KEY_SESSIONS, [
        {
            id: "ses-1",
            autor: "aluno@clinicaescola.edu",
            pacienteId: "pac-1",
            prontuarioId: "pr-1",
            dataSessao: "2026-04-15",
            status: "Enviado para revisão",
            evolucao: "Sessão focada em organização de rotina e manejo de ansiedade."
        },
        {
            id: "ses-2",
            autor: "aluno@clinicaescola.edu",
            pacienteId: "pac-2",
            prontuarioId: "pr-2",
            dataSessao: "2026-04-17",
            status: "Rascunho",
            evolucao: "Levantamento de histórico familiar e fatores de estresse."
        }
    ]);

    seedIfEmpty(KEY_AUDIT, [
        {
            id: "aud-1",
            action: "SEED",
            entity: "Sistema",
            entityId: "demo",
            details: "Carga inicial de dados de demonstração",
            timestamp: new Date().toISOString()
        }
    ]);
}

seedDemoData();
migrateLinksPatientIds();

btnEnter.addEventListener("click", () => {
	// Modo demo: login sem exigir campos válidos.
    const email = loginEmail.value.trim().toLowerCase();

    if (email === "professora@clinicaescola.edu") {
        window.location.href = "administrador/indexAdmin.html";
    } else if (email === "aluno@clinicaescola.edu") {
        window.location.href = "aluno/indexAluno.html";
    } else {
        window.alert("Nao autorizado!");
    }
});

btnFill.addEventListener("click", () => {
    loginEmail.value = "professora@clinicaescola.edu";
    loginPassword.value = "123456";
});
