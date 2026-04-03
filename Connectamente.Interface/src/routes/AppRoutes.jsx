import { BrowserRouter, Routes, Route } from "react-router-dom";

// Import das páginas comuns
import Home from "../pages/Home";
import Login from "../pages/auth/Login";
import Cadastro from "../pages/auth/Cadastro";
import Perfil from "../pages/auth/Perfil";

// Import dos componentes de proteção
import PrivateRoute from "./PrivateRoute";

// Import dos módulos de rotas que eu criei
import { CoordenadorRoutes } from "./CoordenadorRoutes";
import { AlunoRoutes } from "./AlunoRoutes";

function AppRoutes() {
  return (
    <BrowserRouter>
      <Routes>
        {/* --- ROTAS PÚBLICAS --- */}
        <Route path="/" element={<Home />} /> {/*A home deveria ser a tela de login mas nao mexi nisso */}
        <Route path="/login" element={<Login />} />
        <Route path="/cadastro" element={<Cadastro />} />

        {/* --- MÓDULO DO COORDENADOR --- */}
        {/* Envolvemos o módulo inteiro na proteção de tipo "coordenador" */}
        <Route path="coordenador" element={<PrivateRoute tipoPermitido="coordenador" />}>
          {CoordenadorRoutes}
        </Route>

        {/* --- MÓDULO DO ALUNO --- */}
        {/* Envolvemos o módulo inteiro na proteção de tipo "aluno" */}
        <Route path="aluno" element={<PrivateRoute tipoPermitido="aluno" />}>
          {AlunoRoutes}
        </Route>        

        {/* Rota para 404 */}
        <Route path="*" element={<div>Página não encontrada</div>} />
      </Routes>
    </BrowserRouter>
  );
}

export default AppRoutes;