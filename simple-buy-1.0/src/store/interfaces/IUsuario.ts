
export enum EGeneroUsuario{
    NONE = "",
    MASCULINO = "Masculino",
    FEMININO = "Feminino",
    OUTROS = "Outros"
}


export interface IUsuario{
    name: string
    email: string
    genero: EGeneroUsuario
}