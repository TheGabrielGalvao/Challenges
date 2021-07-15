
import {Reducer} from 'redux'
import { products } from './lista'

import {IProductState, EProductActions} from './types'

const INITIAL_STATE:IProductState = {
    list: products
}

const reducer: Reducer<IProductState> = (state = INITIAL_STATE, action) =>{
    switch (action.type) {
        case EProductActions.INDEX:
            return {...state}
        default:
            return state
    }
}

export default reducer