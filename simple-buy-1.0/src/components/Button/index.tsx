import React, { HtmlHTMLAttributes } from 'react'

import './styles.css'

interface Props  extends HtmlHTMLAttributes<HTMLButtonElement>{
    OnClick?: any
    type?: 'submit' | 'reset' | 'button';
}

export const Button:React.FC<Props> = ({OnClick, className, children, type}) => {
    return(
        <button type={type} onClick={OnClick} className={className}>{children}</button>
    )
}