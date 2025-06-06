// <copyright file="PexAssemblyInfo.cs">Copyright ©  2024</copyright>
using Microsoft.Pex.Framework.Coverage;
using Microsoft.Pex.Framework.Creatable;
using Microsoft.Pex.Framework.Instrumentation;
using Microsoft.Pex.Framework.Settings;
using Microsoft.Pex.Framework.Validation;

// Microsoft.Pex.Framework.Settings
[assembly: PexAssemblySettings(TestFramework = "MSTestv2")]

// Microsoft.Pex.Framework.Instrumentation
[assembly: PexAssemblyUnderTest("ShapeHandler")]
[assembly: PexInstrumentAssembly("System.Windows.Forms")]
[assembly: PexInstrumentAssembly("Microsoft.Office.Tools")]
[assembly: PexInstrumentAssembly("Microsoft.Office.Tools.Common")]
[assembly: PexInstrumentAssembly("Microsoft.VisualStudio.Tools.Applications.Runtime")]
[assembly: PexInstrumentAssembly("Microsoft.Office.Tools.Common.v4.0.Utilities")]

// Microsoft.Pex.Framework.Creatable
[assembly: PexCreatableFactoryForDelegates]

// Microsoft.Pex.Framework.Validation
[assembly: PexAllowedContractRequiresFailureAtTypeUnderTestSurface]
[assembly: PexAllowedXmlDocumentedException]

// Microsoft.Pex.Framework.Coverage
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Windows.Forms")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Microsoft.Office.Tools")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Microsoft.Office.Tools.Common")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Microsoft.VisualStudio.Tools.Applications.Runtime")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Microsoft.Office.Tools.Common.v4.0.Utilities")]

