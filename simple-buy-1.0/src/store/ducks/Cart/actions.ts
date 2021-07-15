import { FormErrors } from "redux-form";
import { EGeneroUsuario, IUsuario } from "../../interfaces/IUsuario";
import { ECartActions, IItemCart } from "./types";


export function index(){
    return {
        type: ECartActions.INDEX
    }
}


export function adicionar(item: IItemCart){
    return{
        type: ECartActions.ADD,
        item: item,
        subtotal: item.Subtotal * item.Quantidade
    }   
}

export function finalizar(usuario: IUsuario){
    const errors: FormErrors<IUsuario> = {}
    
    if(usuario == null){
        errors.name = "Campo Nome é obrigatório"
        errors.email = "Campo Email é obrigatório"
        errors.genero = "Campo Sexo/Gênero é obrigatório"
    }

    if(!usuario.name){
        errors.name = "Campo Nome é obrigatório"
    }

    if(!usuario.email){
        errors.email = "Campo Email é obrigatório"
    }

    if(usuario.genero == null || usuario.genero === EGeneroUsuario.NONE){
        errors.genero = "Campo Sexo/Gênero é obrigatório"
    }

    console.log(errors)

    return {
        type: ECartActions.FINALIZAR,
        usuario: usuario,
        validacao: errors
    }
}

export function limpar(){
    return{
        type: ECartActions.CLEAN
    }
}