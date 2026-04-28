const btnLogoutAdmin = document.getElementById("btn-logout-admin");
const navLinks = document.querySelectorAll(".nav-link");
const pages = document.querySelectorAll(".page");

function showPage(pageName) {
	const routes = {
		pacientes: "./Pacientes/index.html",
		prontuario: "./Prontuarios/index.html",
		vinculos: "./Vinculos/index.html",
		documentos: "./Documentos/index.html"
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

btnLogoutAdmin.addEventListener("click", () => {
	window.location.href = "../index.html";
});

navLinks.forEach((link) => {
	link.addEventListener("click", () => {
		showPage(link.dataset.page);
	});
});
