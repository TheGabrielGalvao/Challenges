import { Reducer } from "redux";
import { ECartActions, ICart } from "./types";

const INITIAL_STATE:ICart = {
    Itens: [],
    Total: 0
}

const reducer:Reducer<ICart> = (state= INITIAL_STATE, action) =>{
    switch (action.type) {
        case ECartActions.INDEX:
            return {...state}
        case ECartActions.ADD:
            state.Itens.push(action.item)
            return{...state, Total: state.Total + action.subtotal}
        case ECartActions.FINALIZAR:
            return{...state, Usuario: action.usuario, validacao: action.validacao }
        case ECartActions.CLEAN:
            return{...state, Usuario: null, Total: 0, Itens: [], validacao: null}
        default:
            return state
    }
}

export default reducer