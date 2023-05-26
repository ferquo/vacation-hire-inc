namespace VacationHireInc.Domain.DataTransferObjects
{
    public interface IRentableProductDto
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string ProductType { get; set; }
    }
}