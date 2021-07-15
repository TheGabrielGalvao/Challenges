import {Dispatch, bindActionCreators} from 'redux'
import {connect} from 'react-redux'

import {IProduct} from '../../store/ducks/Product/types'
import * as ProductActions from '../../store/ducks/Product/actions'

import {ApplicationState} from '../../store'
import Card from '../../components/Card'

import './styles.css'
import Footer from '../../components/Footer'

interface Props {
    list: IProduct[]
    index(): void
}

const Products:React.FC<Props> = ({list, index}) =>{

    return(
        
            <div className="container" >
                <header className="">
                    <h1>Produtos</h1>
                    <hr/>   
                </header>
                <br/>
                <div className="products">
                    {list.map((item)=>(
                        <Card key={item.Id} product={item} />
                    ))}
                </div>
                <Footer/>
            </div>
        )
}

const mapStateToProps = (state: ApplicationState) => ({
    list: state.product.list
})

const mapDispatchToProps = (dispatch: Dispatch) => bindActionCreators(ProductActions, dispatch)

export default connect(mapStateToProps, mapDispatchToProps)(Products)