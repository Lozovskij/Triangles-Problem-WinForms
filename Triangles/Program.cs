using Autofac;
using System;
using System.Windows.Forms;
using Triangles.Models.Helpers;
using Triangles.Models.Helpers.Interfaces;
using Triangles.Presenters;
using Triangles.Views;

namespace Triangles
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Container = GetContainer();

            // need to resolve presenter first (letter P in MVP)
            // DI container injects singlton view in presenter
            // and then presenter adds event handlers to view events
            Container.Resolve<TrianglesPresenter>();
            Application.Run(Container.Resolve<TrianglesView>());
        }

        public static IContainer Container { get; private set; }

        /// <summary>
        /// setting DI
        /// </summary>
        /// <returns></returns>
        private static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<TrianglesFileReader>().As<ITrianglesFileReader>();
            builder.RegisterType<TrianglesColorizer>().As<ITrianglesColorizer>();
            builder.RegisterType<TrianglesFactory>().As<ITrianglesFactory>();
            builder.RegisterType<TrianglesView>().As<ITrianglesView>().AsSelf().SingleInstance();
            builder.RegisterType<TrianglesPresenter>();
            return builder.Build();
        }
    }
}
