import { Publication } from "./publication"

export interface userProfile {
    id : string
    fullname : string
    email : string
    description : string
    profilePhotoUrl : string
    publications : Publication[]
}