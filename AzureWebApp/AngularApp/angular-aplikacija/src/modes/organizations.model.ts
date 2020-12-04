import { Student } from './student.model';

export class Organization {
    public name : string;
    public postalCode : string;
    public students : Student [];

    constructor(name:string, postalCode:string, students:[]){
        this.name = name;
        this.postalCode = postalCode;
        this.students = students
    }
}