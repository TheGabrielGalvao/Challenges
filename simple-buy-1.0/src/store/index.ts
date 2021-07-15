import { createStore, applyMiddleware, Store } from 'redux'
import thunk from 'redux-thunk'
import { ICart } from './ducks/Cart/types'
import { IProductState } from './ducks/Product/types'

import rootReducer from './ducks/rootReducer'

export interface ApplicationState {
    product: IProductState
    cart: ICart
}


const store: Store<ApplicationState> = createStore(rootReducer, applyMiddleware(thunk))


export default store