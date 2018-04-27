"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var article_service_service_1 = require("./article-service.service");
describe('ArticleServiceService', function () {
    beforeEach(function () {
        testing_1.TestBed.configureTestingModule({
            providers: [article_service_service_1.ArticleServiceService]
        });
    });
    it('should be created', testing_1.inject([article_service_service_1.ArticleServiceService], function (service) {
        expect(service).toBeTruthy();
    }));
});
//# sourceMappingURL=article-service.service.spec.js.map