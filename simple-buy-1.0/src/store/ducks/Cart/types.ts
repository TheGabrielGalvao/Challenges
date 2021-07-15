import { FormErrors } from "redux-form";
import { IUsuario } from "../../interfaces/IUsuario";
import { IProduct } from "../Product/types";


export enum ECartActions{
    INDEX = "@cart/INDEX",
    ADD = "@cart/ADD",
    CLEAN = "@cart/CLEAN",
    FINALIZAR = "@cart/FINALIZAR"
}


export interface ICart{
    Usuario?: IUsuario
    Itens: IItemCart[]
    Total: number
    validacao?: FormErrors<IUsuario> | any
}

export interface IItemCart{
    Produto: IProduct
    Quantidade: number
    Subtotal: number
}