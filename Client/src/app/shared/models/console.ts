import { IBrand } from "./brand"
import { ICompany } from "./company"
import { ITechnicalSpecification } from "./technicalSpecification"

export interface IConsole {
    id: number
    consoleName: string
    description: string
    manufacturer: string
    releaseDate: string
    price: number
    pictureUrl: string
    brandId: number
    technicalSpecificationId: number
    companyId: number
    brand?: IBrand
    technicalSpecification?: ITechnicalSpecification
    company?: ICompany
}