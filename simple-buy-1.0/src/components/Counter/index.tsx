import { useState } from "react"
import {Dispatch, bindActionCreators} from 'redux'
import {connect} from 'react-redux'
import { Button } from "../Button"

import {FiMinus, FiPlus} from 'react-icons/fi'
import { IProduct} from "../../store/ducks/Product/types"
import { IItemCart } from "../../store/ducks/Cart/types"
import {adicionar} from '../../store/ducks/Cart/actions'
import {ApplicationState} from '../../store'

import './styles.css'

interface StateProps{
    product: IProduct
}

interface DispatchProps{
    adicionar(product: IItemCart): void
}

type Props = StateProps & DispatchProps


const Counter:React.FC<Props> = ({product, adicionar}) =>{
    const [quantidade, setQuantidade] = useState(0)

    const handleAdd = (event:MouseEvent) => {
        event.preventDefault()
        const item: IItemCart = {
            Produto: product,
            Quantidade: quantidade,
            Subtotal: product.Price * quantidade
        }

        adicionar(item)
    }

    return(
        <>
        <div className="counter">
            <div className="form">
                <Button className="btn btn-circle" OnClick={() => setQuantidade((quantidade) > 0 ? quantidade - 1 : 0)} > <FiMinus size={15}/> </Button>
                <input type="text" value={quantidade} className="item" name="quantidade" />
                <Button className="btn btn-circle" OnClick={() => setQuantidade(quantidade + 1)} > <FiPlus size={15}/> </Button>
            </div>
        </div>
        <div style={{display:'flex', justifyContent:'center'}}>
        <Button className="btn btn-card btn-primary" OnClick={handleAdd}>Adicionar</Button>        
        </div>
        </>
    )
}

const mapStateToProps = (state: ApplicationState) => ({})
    
const mapDispatchToProps = (dispatch: Dispatch) => bindActionCreators({adicionar}, dispatch)

export default connect(mapStateToProps, mapDispatchToProps)(Counter)
