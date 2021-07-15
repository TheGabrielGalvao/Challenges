import React from 'react'
import {Switch, Route} from 'react-router-dom'
import Checkout from './pages/Checkout'
import  Products  from './pages/Products'

const Routes = () => {
    return(
        <Switch>
            <Route exact path="/" component={Products} />
            <Route path="/checkout" component={Checkout} />
        </Switch>
    )
}

export default Routes