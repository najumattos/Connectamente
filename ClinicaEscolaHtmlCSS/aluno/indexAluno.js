const btnLogoutStudent = document.getElementById("btn-logout-student");
const navLinks = document.querySelectorAll(".nav-link");
const pages = document.querySelectorAll(".page");

function showPage(pageName) {
	const routes = {
		"meus-pacientes": "./MeusPacientes/index.html",
		"minhas-sessoes": "./MinhasSessoes/index.html",
		"meus-documentos": "./MeusDocumentos/index.html"
	};

	if (routes[pageName]) {
		window.location.href = routes[pageName];
		return;
	}

	navLinks.forEach((link) => {
		const active = link.dataset.page === pageName;
		link.classList.toggle("is-active", active);
	});

	pages.forEach((page) => {
		const active = page.dataset.page === pageName;
		page.classList.toggle("is-active", active);
	});
}

btnLogoutStudent.addEventListener("click", () => {
	window.location.href = "../index.html";
});

navLinks.forEach((link) => {
	link.addEventListener("click", () => {
		showPage(link.dataset.page);
	});
});
