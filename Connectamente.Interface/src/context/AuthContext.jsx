import { createContext, useState, useEffect } from "react"
import AuthService from "../services/AuthService"

export const AuthContext = createContext()

export function AuthProvider({ children }) {
  const [usuario, setUsuario] = useState(null)

  useEffect(() => {
    try {
      const usuarioSalvo = JSON.parse(localStorage.getItem("usuarioLogado"))
      if (usuarioSalvo && localStorage.getItem("token")) setUsuario(usuarioSalvo)
    } catch {
      localStorage.removeItem("usuarioLogado")
      localStorage.removeItem("token")
    }
  }, [])

  async function login(email, senha) {
    const resposta = await AuthService.login({ email, senha })
    const usuarioAutenticado = {
      id: resposta.id,
      nome: resposta.nomeCompleto,
      email: resposta.email,
      perfil: resposta.role?.toLowerCase()
    }

    localStorage.setItem("token", resposta.token)
    localStorage.setItem("usuarioLogado", JSON.stringify(usuarioAutenticado))
    setUsuario(usuarioAutenticado)
    return usuarioAutenticado
  }

  function logout() {
    localStorage.removeItem("usuarioLogado")
    localStorage.removeItem("token")
    setUsuario(null)
  }

  return (
    <AuthContext.Provider value={{ usuario, login, logout }}>
      {children}
    </AuthContext.Provider>
  )
}
