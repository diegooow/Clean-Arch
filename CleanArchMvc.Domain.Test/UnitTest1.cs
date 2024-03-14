namespace CleanArchMvc.Domain.Test;

public class UnitTest1
{
    [Fact]
    public void CreateCategory_WithValidParameters_ResultObjectValidState()
    {
        Action action = ()=> new Category(1,"Category name");
        action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
    }
}