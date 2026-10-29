import { useState, useContext } from "react"
import { useNavigate, Link } from "react-router-dom"
import { AuthContext } from "../../../context/AuthContext"
import "./auth.css"

function Login() {
  const { login } = useContext(AuthContext)
  const navigate = useNavigate()
  const [email, setEmail] = useState("")
  const [senha, setSenha] = useState("")
  const [erro, setErro] = useState("")
  const [carregando, setCarregando] = useState(false)

  async function handleLogin(e) {
    e.preventDefault()
    setErro("")
    setCarregando(true)

    try {
      const usuario = await login(email, senha)
     switch (usuario.perfil?.toLowerCase()) {
  case "professor":
    navigate("/professor");
    break;

  case "aluno":
    navigate("/aluno");
    break;

  case "secretaria":
    navigate("/secretaria");
    break;

   default:
      setErro("Perfil de usuário inválido.")
      break
    } 
    } catch (error) {
      setErro(error.response?.data?.message || "Não foi possível entrar. Verifique seu e-mail e senha.")
    } finally {
      setCarregando(false)
    }
  }

  return (
    <div className="auth-container">
      <div className="auth-card">
        <h2>Entrar</h2>
        <p className="subtitle">Acesse sua conta ConnectaMente</p>

        <form onSubmit={handleLogin}>
          <input
            type="email"
            placeholder="Seu email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
          />

          <input
            type="password"
            placeholder="Sua senha"
            value={senha}
            onChange={(e) => setSenha(e.target.value)}
            required
          />

          {erro && <p role="alert">{erro}</p>}
          <button type="submit" disabled={carregando}>
            {carregando ? "Entrando..." : "Entrar"}
          </button>
        </form>

        <div className="auth-footer">
          Não tem conta? <Link to="/cadastro">Criar conta</Link>
        </div>
      </div>
    </div>
  )
}

export default Login
