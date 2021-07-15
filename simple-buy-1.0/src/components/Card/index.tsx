import React, { HtmlHTMLAttributes } from 'react'

import {IProduct} from '../../store/ducks/Product/types'
import  Counter  from '../Counter'

import './styles.css'

import img from '../../assets/img/produto-01.jpeg'

interface Props extends HtmlHTMLAttributes<HTMLElement>{
    product: IProduct
}

const Card:React.FC<Props> = ({product, ...rest}) =>{
    return(

            // <img src={`${process.env.PUBLIC_URL}/assets/img/${product.Img}`} alt=""/>
        <div className="card">
            <span><img src={`${process.env.PUBLIC_URL}/assets/img/${product.Img}`} alt={product.Name}/></span>
            <div className="box-area">
                <p>{product.Name}</p>
                <p>{Intl.NumberFormat('pt-br', {style: 'currency', currency: 'BRL'}).format(product.Price)}</p>
                <p>{product.Description}</p>
                <div className="phantom">
                    <Counter product={product} />
                </div>
            </div>
        </div>
    )
}

export default Card