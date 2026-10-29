import { BrowserRouter, Routes, Route } from "react-router-dom";

// Import das páginas comuns
import Home from "../pages/Home";
import Login from "../pages/auth/Login";
import Cadastro from "../pages/auth/Cadastro";

// Import dos componentes de proteção
import PrivateRoute from "./PrivateRoute";

// Import dos módulos de rotas que eu criei
import { ProfessorRoutes } from "./ProfessorRoutes";
import { AlunoRoutes } from "./AlunoRoutes";
import { SecretariaRoutes } from "./SecretariaRoutes";

function AppRoutes() {
  return (
    <BrowserRouter>
      <Routes>
        {/* --- ROTAS PÚBLICAS --- */}
        <Route path="/" element={<Home />} /> {/*A home deveria ser a tela de login mas nao mexi nisso */}
        <Route path="/login" element={<Login />} />
        <Route path="/cadastro" element={<Cadastro />} />

        {/* --- MÓDULO DO PROFESSOR --- */}
        {/* Envolvemos o módulo inteiro na proteção de perfil "professor" */}
        <Route path="professor" element={<PrivateRoute perfilPermitido="professor" />}>
          {ProfessorRoutes}
        </Route>

        {/* --- MÓDULO DO ALUNO --- */}
        {/* Envolvemos o módulo inteiro na proteção de perfil "aluno" */}
        <Route path="aluno" element={<PrivateRoute perfilPermitido="aluno" />}>
          {AlunoRoutes}
        </Route>  
         {/* --- MÓDULO DA SECRETARIA --- */}
        {/* Envolvemos o módulo inteiro na proteção de perfil "secretaria" */}
        <Route path="secretaria" element={<PrivateRoute perfilPermitido="secretaria" />}>
          {SecretariaRoutes}
        </Route>        

        {/* Rota para 404 */}
        <Route path="*" element={<div>Página não encontrada</div>} />
      </Routes>
    </BrowserRouter>
  );
}

export default AppRoutes;