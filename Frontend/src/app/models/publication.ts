import { comment } from "./comment"

export interface Publication {
    id : string
    content : string
    imageUrls : string[]
    createAt : string
    likesCount : number
    comments : comment[]
}