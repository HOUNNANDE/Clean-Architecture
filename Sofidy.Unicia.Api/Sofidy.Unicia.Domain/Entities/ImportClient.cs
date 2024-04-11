using Sofidy.Unicia.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofidy.Unicia.Domain.Entities
{
    [Table("IMPORTCLIENTS")]
    /// <summary>
    /// TABLE D&apos;IMPORT DES CLIENTS 
    /// </summary>
    public record ImportClient : BaseImportEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        /// <summary>
        /// Identification de l&apos;enregistrement
        /// </summary>
        public decimal IdImportclients { get; set; }

        /// <summary>
        /// Identification du client (selon codification client)
        /// </summary>
        public string IdClient { get; set; } = null!;

        /// <summary>
        /// Type de données importée - Vide : Création dun Client, C : Informations relativer au conjoint - N: Informations relatives au notaire
        /// </summary>
        public string? CTypeImport { get; set; }

        /// <summary>
        /// Identifiant du conjoint (selon codification client)
        /// </summary>
        public string? IdConjoint { get; set; }

        /// <summary>
        /// Identification de l&apos;agent affecté au client (selon codification client)
        /// </summary>
        public string? IdAgent { get; set; }

        /// <summary>
        /// Identifiant du notaire (selon codification client)
        /// </summary>
        public string? IdNotaire { get; set; }

        /// <summary>
        /// Titre du client (selon codification client)
        /// </summary>
        public string? CTitre { get; set; }

        /// <summary>
        /// Nom du client
        /// </summary>
        public string? TNom { get; set; }

        /// <summary>
        /// Prénom du client
        /// </summary>
        public string? TPrenom { get; set; }

        /// <summary>
        /// Nom de famille du client
        /// </summary>
        public string? TNomFamille { get; set; }

        /// <summary>
        /// Nom du dirigeant
        /// </summary>
        public string? TNomDirigeant { get; set; }

        /// <summary>
        /// Résidence fiscale (selon codification client)
        /// </summary>
        public string? CResident { get; set; }

        /// <summary>
        /// Taux NR (selon codification client)
        /// </summary>
        public string? CTauxNR { get; set; }

        /// <summary>
        /// Mode de règlement (selon codification client)
        /// </summary>
        public string? CModRegl { get; set; }

        /// <summary>
        /// Statut du client (selon codification client)
        /// </summary>
        public string? CStatutClient { get; set; }

        /// <summary>
        /// Adresse 1 du domicile du client
        /// </summary>
        public string? TAdd1Domicile { get; set; }

        /// <summary>
        /// Adresse 2 du domicile du client
        /// </summary>
        public string? TAdd2Domicile { get; set; }

        /// <summary>
        /// Adresse 3 du domicile du client
        /// </summary>
        public string? TAdd3Domicile { get; set; }

        /// <summary>
        /// Code postal de l&apos;adresse du domicile du client
        /// </summary>
        public string? TCPDomicile { get; set; }

        /// <summary>
        /// Ville de l&apos;adresse du domicile du client
        /// </summary>
        public string? TVilleDomicile { get; set; }

        /// <summary>
        /// Pays de l&apos;adresse du domicile du client
        /// </summary>
        public string? TPaysDomicile { get; set; }

        /// <summary>
        /// Adresse 1 fiscale du client
        /// </summary>
        public string? TAdd1Fiscale { get; set; }

        /// <summary>
        /// Adresse 2 fiscale du client
        /// </summary>
        public string? TAdd2Fiscale { get; set; }

        /// <summary>
        /// Adresse 3 fiscale du client
        /// </summary>
        public string? TAdd3Fiscale { get; set; }

        /// <summary>
        /// Code postal de l&apos;adresse fiscale du client
        /// </summary>
        public string? TCPFiscale { get; set; }

        /// <summary>
        /// Ville de l&apos;adresse fiscale du client
        /// </summary>
        public string? TVilleFiscale { get; set; }

        /// <summary>
        /// Pays de l&apos;adresse fiscale du client
        /// </summary>
        public string? TPaysFiscale { get; set; }

        /// <summary>
        /// Adresse 1 de livraison du client
        /// </summary>
        public string? TAdd1Livraison { get; set; }

        /// <summary>
        /// Adresse 2 de livraison du client
        /// </summary>
        public string? TAdd2Livraison { get; set; }

        /// <summary>
        /// Adresse 3 de livraison du client
        /// </summary>
        public string? TAdd3Livraison { get; set; }

        /// <summary>
        /// Code postal de l&apos;adresse de livraison du client
        /// </summary>
        public string? TCPLivraison { get; set; }

        /// <summary>
        /// Ville de l&apos;adresse de livraison du client
        /// </summary>
        public string? TVilleLivraison { get; set; }

        /// <summary>
        /// Pays de l&apos;adresse de livraison du client
        /// </summary>
        public string? TPaysLivraison { get; set; }

        /// <summary>
        /// Numéro de téléphone du client
        /// </summary>
        public string? TTel { get; set; }

        /// <summary>
        /// Numéro de FAX du client
        /// </summary>
        public string? TFax { get; set; }

        /// <summary>
        /// adresse électronique du client
        /// </summary>
        public string? TEmail { get; set; }

        /// <summary>
        /// numéro de SIRET
        /// </summary>
        public string? TSiret { get; set; }

        /// <summary>
        /// code IBAN du compte bancaire client
        /// </summary>
        public string? CIban { get; set; }

        /// <summary>
        /// Code BIC du compte bancaire client
        /// </summary>
        public string? CBic { get; set; }

        /// <summary>
        /// Domiciliation du compte bancaire client
        /// </summary>
        public string? TDom { get; set; }

        /// <summary>
        /// Nom du client assigné au compte bancaire
        /// </summary>
        public string? TTitulaire { get; set; }

        /// <summary>
        /// Situation familiale (selon codification client)
        /// </summary>
        public string? CSitFam { get; set; }

        /// <summary>
        /// Régime matrimonial (selon codification client)
        /// </summary>
        public string? CRegMat { get; set; }

        /// <summary>
        /// Classification du client (selon codification client)
        /// </summary>
        public string? CClassification { get; set; }

        /// <summary>
        /// Statut fiscal du client (Assujetti à l&apos;IR : 1 / Société : 2 / Exonéré : 3)
        /// </summary>
        public string? CRegimeFiscal { get; set; }

        /// <summary>
        /// Crédit d’impôt restituable (O=Oui / N=Non)
        /// </summary>
        public string? FPfl { get; set; }

        /// <summary>
        /// N&apos;habite pas à l&apos;adresse indiquée (O=Oui / N=Non)
        /// </summary>
        public string? FNpai { get; set; }

        /// <summary>
        /// Revenus bloqués (O=Oui / N=Non)
        /// </summary>
        public string? CBloque { get; set; }

        /// <summary>
        /// Date de naissance
        /// </summary>
        public DateTime? DNaissance { get; set; }

        /// <summary>
        /// Date de décès
        /// </summary>
        public DateTime? DDeces { get; set; }

        /// <summary>
        /// Date d&apos;ouverture du dossier de succession
        /// </summary>
        public DateTime? DSuccessdeb { get; set; }

        /// <summary>
        /// Date de fermeture du dossier de succession
        /// </summary>
        public DateTime? DSuccessfin { get; set; }

        /// <summary>
        /// Code NIF (numéro d&apos;identification fiscal)
        /// </summary>
        public string? CCNif { get; set; }

        /// <summary>
        /// Loi sur le compte de la conformité pour impôt étranger (FATCA).  (O=Oui / N=Non)
        /// </summary>
        public string? FFatca { get; set; }

        /// <summary>
        /// Code Insee du département de naissance du client né en France - 99 pour les clients nés à l&apos;étranger
        /// </summary>
        public string? CInseeDepNais { get; set; }

        /// <summary>
        /// Code Insee de la ville de naissance du client - Vide pour les clients nés à l&apos;étranger
        /// </summary>
        public string? CInseeVilleNais { get; set; }

        /// <summary>
        /// Code COG Insee du pays de naissance du client(Alimenté uniquement pour les clients nés à l&apos;étranger)
        /// </summary>
        public string? CInseePaysNaisCog { get; set; }

        /// <summary>
        /// Type de document du client(selon codification client)
        /// </summary>
        public string? CDocType { get; set; }

        /// <summary>
        /// Numéro du document justificatif du client
        /// </summary>
        public string? TDocNumero { get; set; }

        /// <summary>
        /// Ville de Délivrance du document justificatif du client
        /// </summary>
        public string? TDocDelivranceVille { get; set; }

        /// <summary>
        /// Date de délivrance du document justificatif du client
        /// </summary>
        public DateTime? DDocDelivrance { get; set; }

        /// <summary>
        /// Date d&apos;expiration du document justificatif du client
        /// </summary>
        public DateTime? DDocExpiration { get; set; }

        /// <summary>
        /// Commentaire
        /// </summary>
        public string? Tcommentaire { get; set; }

        /// <summary>
        /// Profession du client (selon codification client)
        /// </summary>
        public string? CProfession { get; set; }

        /// <summary>
        /// Gestion de deux codes : Origine du client (dépend du fichier INI)
        /// </summary>
        public string? CliOrig { get; set; }

        /// <summary>
        /// Gestion de deux codes : Code d&apos;origine
        /// </summary>
        public string? CodeOrig { get; set; }

        /// <summary>
        /// Indique si le client est convoqué par e-mail
        /// </summary>
        public string? FConvoquerByEmail { get; set; }

        /// <summary>
        /// Indique si le client active la communication par e-mail pour les distributions
        /// </summary>
        public string? FCommunicByEmailDistrib { get; set; }

        /// <summary>
        /// Indique si le client active la communication par e-mail pour les sessions fiscales
        /// </summary>
        public string? FCommunicByEmailFisca { get; set; }

        /// <summary>
        /// Flag : soumis à l&apos;IFI
        /// </summary>
        public string? Fifi { get; set; }

        /// <summary>
        /// N° de téléphone mobile
        /// </summary>
        public string? TTelMobile { get; set; }

        /// <summary>
        /// Justificatif de domicile
        /// </summary>
        public string? TJustificatifDom { get; set; }

        /// <summary>
        /// Date du document
        /// </summary>
        public DateTime? DDocument { get; set; }

        /// <summary>
        /// Type de document d&apos;état civil du conjoint (NULL:non renseigné, P:Passeport, C:Carte d&apos;identité, V:Permis de conduire)
        /// </summary>
        public string? CTDocumentConjoint { get; set; }

        /// <summary>
        /// Numéro de document d&apos;état civil du conjoint
        /// </summary>
        public string? TNDocumentConjoint { get; set; }

        /// <summary>
        /// Date de délivrance du document d&apos;état civil du conjoint
        /// </summary>
        public DateTime? DDocDelivranceConjoint { get; set; }

        /// <summary>
        /// Lieu de délivrance du document d&apos;état civil du conjoint
        /// </summary>
        public string? TVilleDelivranceConjoint { get; set; }

        /// <summary>
        /// Date d&apos;éxpiration du document d&apos;état civil du conjoint
        /// </summary>
        public DateTime? DDocExpirationConjoint { get; set; }

        /// <summary>
        /// Flag : Retenu à la source au titre du prélèvement forfaitaire unique sur les assiette n°2 &amp; n°3 des revenus financiers
        /// </summary>
        public string? Fpfla2a3 { get; set; }

        /// <summary>
        /// Qualité de l&apos;associé
        /// </summary>
        public string? CQualite { get; set; }

        /// <summary>
        /// Colonne système (référence du dossier)
        /// </summary>
        public string? Sysrefdossier { get; set; }

        /// <summary>
        /// Indique si le dossier a été traité
        /// </summary>
        public string? FTraiter { get; set; }

        /// <summary>
        /// Date d&apos;entrée de l&apos;associé
        /// </summary>
        public DateTime? DEntree { get; set; }

        /// <summary>
        /// Date d&apos;évaluation de l&apos;associé
        /// </summary>
        public DateTime? DEvaluation { get; set; }

        /// <summary>
        /// Code du secteur d&apos;activité de l&apos;associé
        /// </summary>
        public string? CSecteurActivite { get; set; }

        /// <summary>
        /// Code de l&apos;apporteur d&apos;affaire
        /// </summary>
        public string? IdApporteur { get; set; }

        /// <summary>
        /// Secteur d&apos;activité de l&apos;associé
        /// </summary>
        public string? TSecteur { get; set; }

        /// <summary>
        /// Permet d&apos;indiquer si l&apos;enregistrement provient de l&apos;import des dossiers
        /// </summary>
        public string? FSysImportDossiers { get; set; }

        public override decimal Id => this.IdImportclients;

        //public virtual ICollection<Importmvtetape> ImportmvtetapeIdimportclientsnuproNavigations { get; } = new List<Importmvtetape>();

        //public virtual ICollection<Importmvtetape> ImportmvtetapeIdimportclientsusuNavigations { get; } = new List<Importmvtetape>();
    }
}
