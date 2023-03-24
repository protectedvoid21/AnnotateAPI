namespace Services.Annotation; 

public class AnnotationService {
    private readonly IAnnotationService annotationService;

    public AnnotationService(IAnnotationService annotationService) {
        this.annotationService = annotationService;
    }
}