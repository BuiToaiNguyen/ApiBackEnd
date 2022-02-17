﻿using Finbuckle.MultiTenant.EntityFrameworkCore;
using TD.CitizenAPI.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TD.CitizenAPI.Infrastructure.Persistence.Configuration;

public class BrandConfig : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.IsMultiTenant();

        builder
            .Property(b => b.Name)
                .HasMaxLength(256);
    }
}

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.IsMultiTenant();

        builder
            .Property(b => b.Name)
                .HasMaxLength(1024);

        builder
            .Property(p => p.ImagePath)
                .HasMaxLength(2048);
    }
}


public class AttachmentConfig : IEntityTypeConfiguration<Attachment>
{
    public void Configure(EntityTypeBuilder<Attachment> builder)
    {
        builder.IsMultiTenant();
        builder
            .Property(b => b.Name)
                .HasMaxLength(256);
        builder
            .Property(b => b.Type)
                .HasMaxLength(256);
        builder
            .Property(b => b.Url)
                .HasMaxLength(256);
    }
}
