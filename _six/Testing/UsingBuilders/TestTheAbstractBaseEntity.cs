using FluentAssertions;
using Moq;
using TestingDomain.Generic;

namespace UsingBuilders;

public class TestTheAbstractBaseEntity
{
    [Fact]
    public void Terms_can_be_compared()
    {
        var term1 = new Term("a");
        var term2 = new Term("b");

        (term1 != term2).Should().BeTrue();
    }

    [Fact]
    public void Terms_can_apply_equal_sign()
    {
        var term1 = new Term("a");
        var term2 = new Term("a");

        (term1 == term2).Should().BeTrue();
    }

    [Fact]
    public void Two_types_can_be_compared()
    {
        var term1 = new Term("a");
        String term2 = string.Empty;

        term1.Equals(term2).Should().BeFalse();
    }

    [Fact]
    public void Same_references_can_be_compared()
    {
        var term = new Term("a");
        var term1 = term;
        var term2 = term;

        term1.Equals(term2).Should().BeTrue();
    }

    [Fact]
    public void Lef_side_term_is_null_checked()
    {
        Term term1 = null;
        var term2 = new Term("a");

        (term1 == term2).Should().BeFalse();
    }

    [Fact]
    public void Both_terms_null_checked()
    {
        Term term1 = null;
        Term term2 = null;

        (term1 == term2).Should().BeTrue();
    }

    [Fact]
    public void Can_get_hashcode()
    {
        var term1 = new Term("a");
        var x = term1.GetHashCode();

        x.Should().Be(x);
    }

    [Fact]
    public void Can_set_name()
    {
        var term1 = new Term("a");
        term1.Name = "x";
        var x = term1.Name;

        x.Should().Be("x");
    }
}