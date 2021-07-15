import { combineReducers } from 'redux'
import {reducer as formReducer} from 'redux-form'

import product from './Product'
import cart from './Cart'

export default combineReducers({
    product,
    cart,
    form: formReducer,
})