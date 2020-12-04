import { Organization } from './organizations.model';

export class Student { 
    public firstName : string;
    public lastName: string;
    public organization: Organization;

    constructor(firstName : string, lastName: string, organization: Organization){
        this.firstName = firstName;
        this.lastName = lastName;
        this.organization = organization;
    }
}