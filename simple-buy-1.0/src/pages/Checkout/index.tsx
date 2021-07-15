
import {useHistory} from 'react-router-dom'
import {connect} from 'react-redux'
import {bindActionCreators, Dispatch} from 'redux'
import { ICart } from '../../store/ducks/Cart/types'
import { ApplicationState } from '../../store'
import {limpar} from '../../store/ducks/Cart/actions'

import './styles.css'
import { IconCheckout } from '../../components/icons'
import { Button } from '../../components'

interface StateProps {
    cart: ICart
}

interface DispatchProps{
    limpar(): void
}

type Props = StateProps & DispatchProps

const Checkout:React.FC<Props> = ({cart, limpar}) => {
    const history = useHistory()

    const handleCleanState =(e: MouseEvent)=>{
        e.preventDefault()
        limpar()
        history.push("/")
    }

    return(
        <div className="checkout">
            <h3>{cart.Usuario?.name},</h3>
            <p>Sua compra no valor de <span>{Intl.NumberFormat('pt-BR', { style: 'currency', currency: 'BRL' }).format(cart.Total)} </span>
             foi finalizada com sucesso</p>
             <IconCheckout />
            <Button className="btn btn-secondary btn-buy" OnClick={handleCleanState}>Iniciar Nova Compra</Button>
        </div>
    )
}


const mapStateToProps = (state: ApplicationState) => ({
    cart: state.cart
})

const mapDispatchToProps = (dispatch: Dispatch) => bindActionCreators({limpar}, dispatch)

export default connect(mapStateToProps, mapDispatchToProps)(Checkout)
