using AnnotateAPI;
using Microsoft.EntityFrameworkCore;
using Services.Annotations;
using Xunit;

namespace Tests; 

public class AnnotationServiceTests {
    private readonly AnnotationService annotationService;
    
    public AnnotationServiceTests() {
        var options = new DbContextOptions<AnnotateDbContext>();
        var dbContext = new AnnotateDbContext(options);

        annotationService = new AnnotationService(dbContext);
    }
    
    [Fact]
    public async Task Add_NewAnnotation_IsVisibleInDb() {

    }
}