import { Component, ViewEncapsulation } from '@angular/core';
import {Router, ActivatedRoute} from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Helpers } from '../helpers';
import { SecurityService } from '../shared/services/security.service';
@Component({
    selector: 'app-documents',
    templateUrl: './documents.component.html',
    styleUrls: [
        './documents.component.css'
    ],
    encapsulation: ViewEncapsulation.None
})
export class DocumentsComponent {
    constructor(
        private modalService: NgbModal, 
        private securityService: SecurityService,
    ) {
    }
}