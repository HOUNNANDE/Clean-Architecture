using Sofidy.Unicia.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unicia.Model.Models;

[Table("IMPORTAGENTS")]
/// <summary>
/// TABLE POUR IMPORTER LES AGENTS
/// </summary>
public record ImportAgent : BaseImportEntity
{ 

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    /// <summary>
    /// Identification de l&apos;enregistrement
    /// </summary>
    public decimal IdImportAgents { get; set; }

    /// <summary>
    /// Identification de l&apos;agent
    /// </summary>
    public string IDAgent { get; set; } 

    /// <summary>
    /// Catégorie de l&apos;agent (selon codification client)
    /// </summary>
    public string? CTypes { get; set; }

    /// <summary>
    /// Titre de l&apos;agent (selon codification client)
    /// </summary>
    public string? CTitre { get; set; }

    /// <summary>
    /// Nom de l&apos;agent
    /// </summary>
    public string? TNom { get; set; }

    /// <summary>
    /// Prénom de l&apos;agent.
    /// </summary>
    public string? TPrenom { get; set; }

    /// <summary>
    /// Adresse 1 du domicile de l&apos;agent
    /// </summary>
    public string? TAdd1Domicile { get; set; }

    /// <summary>
    /// Adresse 2 du domicile de l&apos;agent
    /// </summary>
    public string? TAdd2Domicile { get; set; }

    /// <summary>
    /// Adresse 3 du domicile de l&apos;agent
    /// </summary>
    public string? TAdd3Domicile { get; set; }

    /// <summary>
    /// Code postal de l&apos;adresse du domicile de l&apos;agent
    /// </summary>
    public string? TCpDomicile { get; set; }

    /// <summary>
    /// Ville de l&apos;adresse du domicile de l&apos;agent
    /// </summary>
    public string? TVilleDomicile { get; set; }

    /// <summary>
    /// Pays de l&apos;adresse du domicile de l&apos;agent
    /// </summary>
    public string? TPaysDomicile { get; set; }

    /// <summary>
    /// Adresse 1 administrative de l&apos;agent
    /// </summary>
    public string? TAdd1Administrative { get; set; }

    /// <summary>
    /// Adresse 2 administrative de l&apos;agent
    /// </summary>
    public string? TAdd2Administrative { get; set; }

    /// <summary>
    /// Adresse 3 administrative de l&apos;agent
    /// </summary>
    public string? TAdd3Administrative { get; set; }

    /// <summary>
    /// Code postal de l&apos;adresse administrative de l&apos;agent
    /// </summary>
    public string? TCpAdministrative { get; set; }

    /// <summary>
    /// Ville de l&apos;adresse administrative de l&apos;agent
    /// </summary>
    public string? TVilleAdministrative { get; set; }

    /// <summary>
    /// Pays de l&apos;adresse administrative de l&apos;agent
    /// </summary>
    public string? TPaysAdministrative { get; set; }

    /// <summary>
    /// N° de Siret de l&apos;agent.
    /// </summary>
    public string? TSiret { get; set; }

    /// <summary>
    /// Mail de l&apos;agent
    /// </summary>
    public string? TEmail { get; set; }

    /// <summary>
    /// Téléphone de l&apos;agent.
    /// </summary>
    public string? TTel { get; set; }

    /// <summary>
    /// Fax de l&apos;agent.
    /// </summary>
    public string? TFax { get; set; }

    /// <summary>
    /// Identifiant du manager de l&apos;agent.
    /// </summary>
    public string? IdManager { get; set; }

    /// <summary>
    /// Date de début de mandat
    /// </summary>
    public DateTime? DDeb { get; set; }

    /// <summary>
    /// Date de fin de mandat
    /// </summary>
    public DateTime? DFin { get; set; }

    /// <summary>
    /// Code IBAN de l&apos;agent.
    /// </summary>
    public string? CIban { get; set; }

    /// <summary>
    /// Code BIC de l&apos;agent.
    /// </summary>
    public string? CBic { get; set; }

    /// <summary>
    /// Domiciliation du compte bancaire agent
    /// </summary>
    public string? TDom { get; set; }

    /// <summary>
    /// Titulaire du compte.
    /// </summary>
    public string? TTitulaire { get; set; }

    public override decimal Id => this.IdImportAgents;
}
