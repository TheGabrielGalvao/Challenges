
export enum EProductActions{
    INDEX = "@product/INDEX"
}


export interface IProduct{
    Id: number
    Name: string
    Description: string
    Price: number
    Img: string
}

export interface IProductState{
    list: IProduct[]
}